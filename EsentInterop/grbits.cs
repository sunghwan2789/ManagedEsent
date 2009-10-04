﻿//-----------------------------------------------------------------------
// <copyright file="grbits.cs" company="Microsoft Corporation">
//     Copyright (c) Microsoft Corporation.
// </copyright>
//-----------------------------------------------------------------------

namespace Microsoft.Isam.Esent.Interop
{
    using System;
    using Microsoft.Isam.Esent.Interop.Server2003;
    using Microsoft.Isam.Esent.Interop.Windows7;

    /// <summary>
    /// Options for JetCreateInstance2.
    /// </summary>
    public enum CreateInstanceGrbit
    {
        /// <summary>
        /// Default options.
        /// </summary>
        None = 0,
    }

    /// <summary>
    /// Options for JetInit2.
    /// </summary>
    /// <seealso cref="Windows7Grbits.ReplayIgnoreLostLogs"/>
    [Flags]
    public enum InitGrbit
    {
        /// <summary>
        /// Default options.
        /// </summary>
        None = 0
    }

    /// <summary>
    /// Options for JetTerm2.
    /// </summary>
    /// <seealso cref="Windows7Grbits.Dirty"/>
    public enum TermGrbit
    {
        /// <summary>
        /// Default options.
        /// </summary>
        None = 0,
        
        /// <summary>
        /// Requests that the instance be shut down cleanly. Any optional
        /// cleanup work that would ordinarily be done in the background at
        /// run time is completed immediately.
        /// </summary>
        Complete = 1,

        /// <summary>
        /// Requests that the instance be shut down as quickly as possible.
        /// Any optional work that would ordinarily be done in the
        /// background at run time is abandoned. 
        /// </summary>
        Abrupt = 2,
    }

    /// <summary>
    /// Options for JetCreateDatabase.
    /// </summary>
    [Flags]
    public enum CreateDatabaseGrbit
    {
        /// <summary>
        /// Default options.
        /// </summary>
        None = 0,

        /// <summary>
        /// By default, if JetCreateDatabase is called and the database already exists,
        /// the Api call will fail and the original database will not be overwritten.
        /// OverwriteExisting changes this behavior, and the old database
        /// will be overwritten with a new one.
        /// </summary>
        OverwriteExisting = 0x200,

        /// <summary>
        /// Turns off logging. Setting this bit loses the ability to replay log files
        /// and recover the database to a consistent usable state after a crash.
        /// </summary>
        RecoveryOff = 0x8,
    }

    /// <summary>
    /// Options for JetAttachDatabase.
    /// </summary>
    [Flags]
    public enum AttachDatabaseGrbit
    {
        /// <summary>
        /// Default options.
        /// </summary>
        None = 0,

        /// <summary>
        ///  Prevents modifications to the database.
        /// </summary>
        ReadOnly = 0x1,

        /// <summary>
        /// If JET_paramEnableIndexChecking has been set, all indexes over Unicode
        /// data will be deleted.
        /// </summary>
        DeleteCorruptIndexes = 0x10, 
    }

    /// <summary>
    /// Options for JetOpenDatabase.
    /// </summary>
    [Flags]
    public enum OpenDatabaseGrbit
    {
        /// <summary>
        /// Default options.
        /// </summary>
        None = 0,

        /// <summary>
        /// Prevents modifications to the database.
        /// </summary>
        ReadOnly = 0x1,

        /// <summary>
        /// Allows only a single session to attach a database.
        /// Normally, several sessions can open a database.
        /// </summary>
        Exclusive = 0x2,
    }

    /// <summary>
    /// Options for JetCloseDatabase.
    /// </summary>
    [Flags]
    public enum CloseDatabaseGrbit
    {
        /// <summary>
        /// Default options.
        /// </summary>
        None = 0,
    }

    /// <summary>
    /// Options for <see cref="Api.JetCompact"/>.
    /// </summary>
    [Flags]
    public enum CompactGrbit
    {
        /// <summary>
        /// Default options.
        /// </summary>
        None = 0,

        /// <summary>
        /// Causes JetCompact to dump statistics on the source database to a file
        ///  named DFRGINFO.TXT. Statistics include the name of each table in
        /// source database, number of rows in each table, total size in bytes of
        /// all rows in each table, total size in bytes of all columns of type
        /// <see cref="JET_coltyp.LongText"/> or <see cref="JET_coltyp.LongBinary"/>
        /// that were large enough to be stored separate from the record, number
        /// of clustered index leaf pages, and the number of long value leaf pages.
        /// In addition, summary statistics including the size of the source database,
        /// destination database, time required for database compaction, temporary
        /// database space are all dumped as well.
        /// </summary>
        Stats = 0x20,

        /// <summary>
        /// Used when the source database is known to be corrupt. It enables a
        /// whole set of new behaviors intended to salvage as much data as
        /// possible from the source database. JetCompact with this option set
        /// may return <see cref="JET_err.Success"/> but not copy all of the data
        /// created in the source database. Data that was in damaged portions of
        /// the source database will be skipped.
        /// </summary>
        [Obsolete]
        Repair = 0x40,        
    }

    /// <summary>
    /// Options for <see cref="Api.JetBackupInstance"/>.
    /// </summary>
    public enum BackupGrbit
    {
        /// <summary>
        /// Default options.
        /// </summary>
        None = 0,
        
        /// <summary>
        /// Creates an incremental backup as opposed to a full backup. This
        /// means that only the log files created since the last full or
        /// incremental backup will be backed up.
        /// </summary>
        Incremental = 0x1,

        /// <summary>
        /// Creates a full backup of the database. This allows the preservation
        /// of an existing backup in the same directory if the new backup fails.
        /// </summary>
        Atomic = 0x4,
    }

    /// <summary>
    /// Options for <see cref="Api.JetBeginExternalBackupInstance"/>.
    /// </summary>
    public enum BeginExternalBackupGrbit
    {
        /// <summary>
        /// Default options.
        /// </summary>
        None = 0,

        /// <summary>
        /// Creates an incremental backup as opposed to a full backup. This
        /// means that only the log files since the last full or incremental
        /// backup will be backed up.
        /// </summary>
        Incremental = 0x1,
    }

    /// <summary>
    /// Options for <see cref="Api.JetBeginTransaction2"/>.
    /// </summary>
    public enum BeginTransactionGrbit
    {
        /// <summary>
        /// Default options.
        /// </summary>
        None = 0,

        /// <summary>
        /// The transaction will not modify the database. If an update is attempted,
        /// that operation will fail with <see cref="JET_err.TransReadOnly"/>. This
        /// option is ignored unless it is requested when the given session is not
        /// already in a transaction.
        /// </summary>
        ReadOnly = 0x1,
    }

    /// <summary>
    /// Options for JetCommitTransaction.
    /// </summary>
    [Flags]
    public enum CommitTransactionGrbit
    {
        /// <summary>
        /// Default options.
        /// </summary>
        None = 0,

        /// <summary>
        /// The transaction is committed normally but this Api does not wait for
        /// the transaction to be flushed to the transaction log file before returning
        /// to the caller. This drastically reduces the duration of a commit operation
        /// at the cost of durability. Any transaction that is not flushed to the log
        /// before a crash will be automatically aborted during crash recovery during
        /// the next call to JetInit. If WaitLastLevel0Commit or WaitAllLevel0Commit
        /// are specified, this option is ignored.
        /// </summary>
        LazyFlush = 0x1,

        /// <summary>
        ///  If the session has previously committed any transactions and they have not yet
        ///  been flushed to the transaction log file, they should be flushed immediately.
        ///  This Api will wait until the transactions have been flushed before returning
        ///  to the caller. This is useful if the application has previously committed several
        ///  transactions using JET_bitCommitLazyFlush and now wants to flush all of them to disk.
        /// </summary>
        /// <remarks>
        /// This option may be used even if the session is not currently in a transaction.
        /// This option cannot be used in combination with any other option.
        /// </remarks>
        WaitLastLevel0Commit = 0x2,
    }

    /// <summary>
    /// Options for JetRollbackTransaction.
    /// </summary>
    public enum RollbackTransactionGrbit
    {
        /// <summary>
        /// Default options.
        /// </summary>
        None = 0,

        /// <summary>
        /// This option requests that all changes made to the state of the
        /// database during all save points be undone. As a result, the
        /// session will exit the transaction.
        /// </summary>
        RollbackAll = 0x1,
    }

    /// <summary>
    /// Options for JetEndSession.
    /// </summary>
    public enum EndSessionGrbit
    {
        /// <summary>
        /// Default options.
        /// </summary>
        None,
    }

    /// <summary>
    /// Options for JetOpenTable.
    /// </summary>
    [Flags]
    public enum OpenTableGrbit
    {
        /// <summary>
        /// Default options.
        /// </summary>
        None = 0,

        /// <summary>
        /// This table cannot be opened for read access by another session.
        /// </summary>
        DenyRead,

        /// <summary>
        /// This table cannot be opened for write access by another session.
        /// </summary>
        DenyWrite,

        /// <summary>
        /// Do not cache pages for this table.
        /// </summary>
        NoCache,

        /// <summary>
        /// Allow DDL modifications to a table flagged as FixedDDL. This option
        /// must be used with DenyRead.
        /// </summary>
        PermitDDL,

        /// <summary>
        /// Provides a hint that the table is probably not in the buffer cache, and
        /// that pre-reading may be beneficial to performance.
        /// </summary>
        Preread,

        /// <summary>
        /// Request read-only access to the table.
        /// </summary>
        ReadOnly,

        /// <summary>
        /// Assume a sequential access pattern and prefetch database pages.
        /// </summary>
        Sequential,

        /// <summary>
        /// Request write access to the table.
        /// </summary>
        Updatable,
    }

    /// <summary>
    /// Options for JetDupCursor.
    /// </summary>
    public enum DupCursorGrbit
    {
        /// <summary>
        /// Default options.
        /// </summary>
        None = 0,
    }

    /// <summary>
    /// Options for JetSetColumn.
    /// </summary>
    /// <seealso cref="Windows7Grbits.Compressed"/>
    /// <seealso cref="Windows7Grbits.Uncompressed"/>
    [Flags]
    public enum SetColumnGrbit
    {
        /// <summary>
        /// Default options.
        /// </summary>
        None = 0,

        /// <summary>
        /// This option is used to append data to a column of type JET_coltypLongText
        /// or JET_coltypLongBinary. The same behavior can be achieved by determining
        /// the size of the existing long value and specifying ibLongValue in psetinfo.
        /// However, its simpler to use this grbit since knowing the size of the existing
        /// column value is not necessary.
        /// </summary>
        AppendLV = 0x1,

        /// <summary>
        /// This option is used replace the existing long value with the newly provided
        /// data. When this option is used, it is as though the existing long value has
        /// been set to 0 (zero) length prior to setting the new data.
        /// </summary>
        OverwriteLV = 0x4,

        /// <summary>
        /// This option is only applicable for tagged, sparse or multi-valued columns.
        /// It causes the column to return the default column value on subsequent retrieve
        /// column operations. All existing column values are removed.
        /// </summary>
        RevertToDefaultValue = 0x200,

        /// <summary>
        /// This option is used to force a long value, columns of type JET_coltyp.LongText
        /// or JET_coltyp.LongBinary, to be stored separately from the remainder of record
        /// data. This occurs normally when the size of the long value prevents it from being 
        /// stored with remaining record data. However, this option can be used to force the
        /// long value to be stored separately. Note that long values four bytes in size
        /// of smaller cannot be forced to be separate. In such cases, the option is ignored.
        /// </summary>
        SeparateLV = 0x40,

        /// <summary>
        /// This option is used to interpret the input buffer as a integer number of bytes
        /// to set as the length of the long value described by the given columnid and if
        /// provided, the sequence number in psetinfo->itagSequence. If the size given is
        /// larger than the existing column value, the column will be extended with 0s.
        /// If the size is smaller than the existing column value then the value will be
        /// truncated.
        /// </summary>
        SizeLV = 0x8,

        /// <summary>
        /// This option is used to enforce that all values in a multi-valued column are
        /// distinct. This option compares the source column data, without any
        /// transformations, to other existing column values and an error is returned
        /// if a duplicate is found. If this option is given, then AppendLV, OverwriteLV
        /// and SizeLV cannot also be given.
        /// </summary>
        UniqueMultiValues = 0x80,

        /// <summary>
        /// This option is used to enforce that all values in a multi-valued column are
        /// distinct. This option compares the key normalized transformation of column
        /// data, to other similarly transformed existing column values and an error is
        /// returned if a duplicate is found. If this option is given, then AppendLV, 
        /// OverwriteLV and SizeLV cannot also be given.
        /// </summary>
        UniqueNormalizedMultiValues = 0x100,

        /// <summary>
        /// This option is used to set a value to zero length. Normally, a column value
        /// is set to NULL by passing a cbMax of 0 (zero). However, for some types, like
        /// JET_coltyp.Text, a column value can be 0 (zero) length instead of NULL, and
        /// this option is used to differentiate between NULL and 0 (zero) length.
        /// </summary>
        ZeroLength = 0x20,

        /// <summary>
        /// Try to store long-value columns in the record, even if they exceed the default
        /// separation size.
        /// </summary>
        IntrinsicLV = 0x400,
    }

    /// <summary>
    /// Options for JetRetrieveColumn.
    /// </summary>
    [Flags]
    public enum RetrieveColumnGrbit
    {
        /// <summary>
        /// Default options.
        /// </summary>
        None = 0,

        /// <summary>
        ///  This flag causes retrieve column to retrieve the modified value instead of
        ///  the original value. If the value has not been modified, then the original
        ///  value is retrieved. In this way, a value that has not yet been inserted or
        ///  updated may be retrieved during the operation of inserting or updating a record.
        /// </summary>
        RetrieveCopy = 0x1,

        /// <summary>
        /// This option is used to retrieve column values from the index, if possible,
        /// without accessing the record. In this way, unnecessary loading of records
        /// can be avoided when needed data is available from index entries themselves.
        /// </summary>
        RetrieveFromIndex = 0x2,
        
        /// <summary>
        /// This option is used to retrieve column values from the index bookmark,
        /// and may differ from the index value when a column appears both in the
        /// primary index and the current index. This option should not be specified
        /// if the current index is the clustered, or primary, index. This bit cannot
        /// be set if RetrieveFromIndex is also set. 
        /// </summary>
        RetrieveFromPrimaryBookmark = 0x4,

        /// <summary>
        /// This option is used to retrieve the sequence number of a multi-valued
        /// column value in JET_RETINFO.itagSequence. Retrieving the sequence number
        /// can be a costly operation and should only be done if necessary. 
        /// </summary>
        RetrieveTag = 0x8,

        /// <summary>
        /// This option is used to retrieve multi-valued column NULL values. If
        /// this option is not specified, multi-valued column NULL values will
        /// automatically be skipped. 
        /// </summary>
        RetrieveNull = 0x10,

        /// <summary>
        /// This option affects only multi-valued columns and causes a NULL
        /// value to be returned when the requested sequence number is 1 and
        /// there are no set values for the column in the record. 
        /// </summary>
        RetrieveIgnoreDefault = 0x20,
    }

    /// <summary>
    /// Options for JetEnumerateColumns.
    /// </summary>
    /// <seealso cref="Server2003Grbits.EnumerateIgnoreUserDefinedDefault"/>
    /// <seealso cref="Windows7Grbits.EnumerateInRecordOnly"/>
    [Flags]
    public enum EnumerateColumnsGrbit
    {
        /// <summary>
        /// Default options.
        /// </summary>
        None = 0,

        /// <summary>
        /// When enumerating column values, all columns for which we are retrieving
        /// all values and that have only one non-NULL column value may be returned
        /// in a compressed format. The status for such columns will be set to
        /// <see cref="JET_wrn.ColumnSingleValue"/> and the size of the column value
        /// and the memory containing the column value will be returned directly in
        /// the <see cref="JET_ENUMCOLUMN"/> structure. It is not guaranteed that
        /// all eligible columns are compressed in this manner. See
        /// <see cref="JET_ENUMCOLUMN"/> for more information.
        /// </summary>
        EnumerateCompressOutput = 0x00080000,

        /// <summary>
        /// This option indicates that the modified column values of the record
        /// should be enumerated rather than the original column values. If a
        /// column value has not been modified, the original column value is
        /// enumerated. In this way, a column value that has not yet been inserted
        /// or updated may be enumerated when inserting or updating a record.
        /// </summary>
        /// <remarks>
        /// This option is identical to <see cref="RetrieveColumnGrbit.RetrieveCopy"/>.
        /// </remarks>
        EnumerateCopy = 0x1,

        /// <summary>
        /// If a given column is not present in the record then no column value
        /// will be returned. Ordinarily, the default value for the column,
        /// if any, would be returned in this case. It is guaranteed that if the
        /// column is set to a value different than the default value then that
        /// different value will be returned (that is, if a column with a
        /// default value is explicitly set to NULL then a NULL will be returned
        /// as the value for that column). Even if this option is requested, it
        /// is still possible to see a column value that happens to be equal to
        /// the default value. No effort is made to remove column values that
        /// match their default values.
        /// It is important to remember that this option affects the output of
        /// <see cref="Api.JetEnumerateColumns"/> when used with 
        /// <see cref="EnumerateColumnsGrbit.EnumeratePresenceOnly"/> or
        /// <see cref="EnumerateColumnsGrbit.EnumerateTaggedOnly"/>.
        /// </summary>
        EnumerateIgnoreDefault = 0x20,

        /// <summary>
        /// If a non-NULL value exists for the requested column or column value
        /// then the associated data is not returned. Instead, the associated
        /// status for that column or column value will be set to
        /// <see cref="JET_wrn.ColumnPresent"/>. If the column or column value
        /// is NULL then <see cref="JET_wrn.ColumnNull"/> will be returned as usual.
        /// </summary>
        EnumeratePresenceOnly = 0x00020000,

        /// <summary>
        /// When enumerating all column values in the record (for example,that is
        /// when numColumnids is zero), only tagged column values will be returned.
        /// This option is not allowed when enumerating a specific array of column IDs.
        /// </summary>
        EnumerateTaggedOnly = 0x00040000, 
    }

    /// <summary>
    /// Options for JetMove.
    /// </summary>
    public enum MoveGrbit
    {
        /// <summary>
        /// Default options.
        /// </summary>
        None,

        /// <summary>
        /// Moves the cursor forward or backward by the number of index entries
        /// required to skip the requested number of index key values encountered
        /// in the index. This has the effect of collapsing index entries with
        /// duplicate key values into a single index entry.
        /// </summary>
        MoveKeyNE = 0x1,
    }

    /// <summary>
    /// Options for JetMakeKey.
    /// </summary>
    [Flags]
    public enum MakeKeyGrbit
    {
        /// <summary>
        /// Default options.
        /// </summary>
        None,

        /// <summary>
        /// A new search key should be constructed. Any previously existing search
        /// key is discarded.
        /// </summary>
        NewKey = 0x1,

        /// <summary>
        /// When this option is specified, all other options are ignored, any
        /// previously existing search key is discarded, and the contents of the
        /// input buffer are loaded as the new search key.
        /// </summary>
        NormalizedKey = 0x8,

        /// <summary>
        /// If the size of the input buffer is zero and the current key column
        /// is a variable length column, this option indicates that the input
        /// buffer contains a zero length value. Otherwise, an input buffer size
        /// of zero would indicate a NULL value.
        /// </summary>
        KeyDataZeroLength = 0x10,

        /// <summary>
        /// This option indicates that the search key should be constructed
        /// such that any key columns that come after the current key column
        /// should be considered to be wildcards.
        /// </summary>
        StrLimit = 0x2,

        /// <summary>
        /// This option indicates that the search key should be constructed
        /// such that the current key column is considered to be a prefix
        /// wildcard and that any key columns that come after the current
        /// key column should be considered to be wildcards.
        /// </summary>
        SubStrLimit = 0x4,

        /// <summary>
        /// The search key should be constructed such that any key columns
        /// that come after the current key column should be considered to
        /// be wildcards.
        /// </summary>
        FullColumnStartLimit = 0x100,

        /// <summary>
        /// The search key should be constructed in such a way that any key
        /// columns that come after the current key column are considered to
        /// be wildcards.
        /// </summary>
        FullColumnEndLimit = 0x200,

        /// <summary>
        /// The search key should be constructed such that the current key
        /// column is considered to be a prefix wildcard and that any key
        /// columns that come after the current key column should be considered
        /// to be wildcards. 
        /// </summary>
        PartialColumnStartLimit = 0x400,

        /// <summary>
        /// The search key should be constructed such that the current key
        /// column is considered to be a prefix wildcard and that any key
        /// columns that come after the current key column should be considered
        /// to be wildcards.
        /// </summary>
        PartialColumnEndLimit = 0x800,
    }

    /// <summary>
    /// Options for JetRetrieveKey.
    /// </summary>
    public enum RetrieveKeyGrbit
    {
        /// <summary>
        /// Default options.
        /// </summary>
        None = 0,

        /// <summary>
        /// Retrieve the currently constructed key.
        /// </summary>
        RetrieveCopy = 0x1,
    }

    /// <summary>
    /// Options for JetSeek.
    /// </summary>
    [Flags]
    public enum SeekGrbit
    {
        /// <summary>
        /// The cursor will be positioned at the index entry closest to the
        /// start of the index that exactly matches the search key.
        /// </summary>
        SeekEQ = 0x1,

        /// <summary>
        /// The cursor will be positioned at the index entry closest to the
        /// end of the index that is less than an index entry that would
        /// exactly match the search criteria.
        /// </summary>
        SeekLT = 0x2,

        /// <summary>
        /// The cursor will be positioned at the index entry closest to the
        /// end of the index that is less than or equal to an index entry
        /// that would exactly match the search criteria.
        /// </summary>
        SeekLE = 0x4,

        /// <summary>
        /// The cursor will be positioned at the index entry closest to the
        /// start of the index that is greater than or equal to an index
        /// entry that would exactly match the search criteria.
        /// </summary>
        SeekGE = 0x8,

        /// <summary>
        /// The cursor will be positioned at the index entry closest to the
        /// start of the index that is greater than an index entry that
        /// would exactly match the search criteria.
        /// </summary>
        SeekGT = 0x10,

        /// <summary>
        /// An index range will automatically be setup for all keys that
        /// exactly match the search key. 
        /// </summary>
        SetIndexRange = 0x20,
    }

    /// <summary>
    /// Options for JetSetIndexRange.
    /// </summary>
    [Flags]
    public enum SetIndexRangeGrbit
    {
        /// <summary>
        /// Default options.
        /// </summary>
        None = 0x0,

        /// <summary>
        /// This option indicates that the limit of the index range is inclusive.
        /// </summary>
        RangeInclusive = 0x1,

        /// <summary>
        /// The search key in the cursor represents the search criteria for the
        /// index entry closest to the end of the index that will match the index
        /// range. 
        /// </summary>
        RangeUpperLimit = 0x2,

        /// <summary>
        /// The index range should be removed as soon as it has been established.
        /// This is useful for testing for the existence of index entries that
        /// match the search criteria.
        /// </summary>
        RangeInstantDuration = 0x4,

        /// <summary>
        /// Cancel and existing index range.
        /// </summary>
        RangeRemove = 0x8,
    }

    /// <summary>
    /// Options for the JET_INDEXRANGE object.
    /// </summary>
    public enum IndexRangeGrbit
    {
        /// <summary>
        /// Records in the cursors indexrange should be included in the output.
        /// </summary>
        RecordInIndex = 0x1,
    }

    /// <summary>
    /// Options for JetIntersectIndexes.
    /// </summary>
    public enum IntersectIndexesGrbit
    {
        /// <summary>
        /// Default options.
        /// </summary>
        None = 0,
    }

    /// <summary>
    /// Options for JetSetTableSequential.
    /// </summary>
    public enum SetTableSequentialGrbit
    {
        /// <summary>
        /// Default options.
        /// </summary>
        None = 0,
    }

    /// <summary>
    /// Options for JetResetTableSequential.
    /// </summary>
    public enum ResetTableSequentialGrbit
    {
        /// <summary>
        /// Default options.
        /// </summary>
        None = 0,
    }

    /// <summary>
    /// Options for JetGetLock.
    /// </summary>
    public enum GetLockGrbit
    {
        /// <summary>
        /// Acquire a read lock on the current record. Read locks are incompatible with
        /// write locks already held by other sessions but are compatible with read locks
        /// held by other sessions.
        /// </summary>
        Read = 0x1,

        /// <summary>
        ///  Acquire a write lock on the current record. Write locks are not compatible
        ///  with write or read locks held by other sessions but are compatible with
        ///  read locks held by the same session.
        /// </summary>
        Write = 0x2,
    }

    /// <summary>
    /// Options for JetEscrowUpdate.
    /// </summary>
    public enum EscrowUpdateGrbit
    {
        /// <summary>
        /// Default options.
        /// </summary>
        None = 0,

        /// <summary>
        /// Even if the session performing the escrow update has its transaction rollback
        /// this update will not be undone. As the log records may not be flushed to disk,
        /// recent escrow updates done with this flag may be lost if there is a crash.
        /// </summary>
        NoRollback = 0x1,
    }

    /// <summary>
    /// Options for the JET_COLUMNDEF structure.
    /// </summary>
    /// <seealso cref="Windows7Grbits.ColumnCompressed"/>
    [Flags]
    public enum ColumndefGrbit
    {
        /// <summary>
        /// Default options.
        /// </summary>
        None = 0x0,

        /// <summary>
        /// The column will be fixed. It will always use the same amount of space in a row,
        /// regardless of how much data is being stored in the column. ColumnFixed
        /// cannot be used with ColumnTagged. This bit cannot be used with long values
        /// (that is JET_coltyp.LongText and JET_coltyp.LongBinary).
        /// </summary>
        ColumnFixed = 0x1,

        /// <summary>
        ///  The column will be tagged. Tagged columns do not take up any space in the database
        ///  if they do not contain data. This bit cannot be used with ColumnFixed.
        /// </summary>
        ColumnTagged = 0x2,

        /// <summary>
        /// The column must never be set to a NULL value. On Windows XP this can only be applied to
        /// fixed columns (bit, byte, integer, etc).
        /// </summary>
        ColumnNotNULL = 0x4,

        /// <summary>
        /// The column is a version column that specifies the version of the row. The value of
        /// this column starts at zero and will be automatically incremented for each update on
        /// the row. This option can only be applied to JET_coltyp.Long columns. This option cannot
        /// be used with ColumnAutoincrement, ColumnEscrowUpdate, or ColumnTagged.
        /// </summary>
        ColumnVersion = 0x8,

        /// <summary>
        /// The column will automatically be incremented. The number is an increasing number, and
        /// is guaranteed to be unique within a table. The numbers, however, might not be continuous.
        /// For example, if five rows are inserted into a table, the "autoincrement" column could
        /// contain the values { 1, 2, 6, 7, 8 }. This bit can only be used on columns of type
        /// JET_coltyp.Long or JET_coltyp.Currency.
        /// </summary>
        ColumnAutoincrement = 0x10,

        /// <summary>
        /// The column can be multi-valued.
        /// A multi-valued column can have zero, one, or more values
        /// associated with it. The various values in a multi-valued column are identified by a number
        /// called the itagSequence member, which belongs to various structures, including:
        /// JET_RETINFO, JET_SETINFO, JET_SETCOLUMN, JET_RETRIEVECOLUMN, and JET_ENUMCOLUMNVALUE.
        /// Multi-valued columns must be tagged columns; that is, they cannot be fixed-length or
        /// variable-length columns.
        /// </summary>
        ColumnMultiValued = 0x400,

        /// <summary>
        ///  Specifies that a column is an escrow update column. An escrow update column can be
        ///  updated concurrently by different sessions with JetEscrowUpdate and will maintain
        ///  transactional consistency. An escrow update column must also meet the following conditions:
        ///  An escrow update column can be created only when the table is empty. 
        ///  An escrow update column must be of type JET_coltypLong. 
        ///  An escrow update column must have a default value.
        ///  JET_bitColumnEscrowUpdate cannot be used in conjunction with ColumnTagged,
        ///  ColumnVersion, or ColumnAutoincrement. 
        /// </summary>
        ColumnEscrowUpdate = 0x800,

        /// <summary>
        /// The column will be created in an without version information. This means that other
        /// transactions that attempt to add a column with the same name will fail. This bit
        /// is only useful with JetAddColumn. It cannot be used within a transaction.
        /// </summary>
        ColumnUnversioned = 0x1000,

        /// <summary>
        /// The default value for a column will be provided by a callback function. A column that
        /// has a user-defined default must be a tagged column. Specifying JET_bitColumnUserDefinedDefault
        /// means that pvDefault must point to a JET_USERDEFINEDDEFAULT structure, and cbDefault must be
        /// set to sizeof( JET_USERDEFINEDDEFAULT ).
        /// </summary>
        ColumnUserDefinedDefault = 0x8000,

        /// <summary>
        /// The column will be a key column for the temporary table. The order
        /// of the column definitions with this option specified in the input
        /// array will determine the precedence of each key column for the
        /// temporary table. The first column definition in the array that
        /// has this option set will be the most significant key column and
        /// so on. If more key columns are requested than can be supported
        /// by the database engine then this option is ignored for the
        /// unsupportable key columns.
        /// </summary>
        TTKey = 0x40,

        /// <summary>
        /// The sort order of the key column for the temporary table should
        /// be descending rather than ascending. If this option is specified
        ///  without <see cref="TTKey"/> then this option is ignored.
        /// </summary>
        TTDescending = 0x80,
    }

    /// <summary>
    /// Options for JetCreateIndex.
    /// </summary>
    [Flags]
    public enum CreateIndexGrbit
    {        
        /// <summary>
        /// Default options.
        /// </summary>
        None = 0x0,

        /// <summary>
        /// Duplicate index entries (keys) are disallowed. This is enforced when JetUpdate is called,
        /// not when JetSetColumn is called.
        /// </summary>
        IndexUnique  = 0x1,

        /// <summary>
        /// The index is a primary (clustered) index. Every table must have exactly one primary index.
        /// If no primary index is explicitly defined over a table, then the database engine will
        /// create its own primary index.
        /// </summary>
        IndexPrimary = 0x2,

        /// <summary>
        /// None of the columns over which the index is created may contain a NULL value.
        /// </summary>
        IndexDisallowNull = 0x4,

        /// <summary>
        /// Do not add an index entry for a row if all of the columns being indexed are NULL.
        /// </summary>
        IndexIgnoreNull = 0x8,

        /// <summary>
        /// Do not add an index entry for a row if any of the columns being indexed are NULL.
        /// </summary>
        IndexIgnoreAnyNull = 0x20,

        /// <summary>
        /// Do not add an index entry for a row if the first column being indexed is NULL.
        /// </summary>
        IndexIgnoreFirstNull = 0x40,

        /// <summary>
        /// Specifies that the index operations will be logged lazily. JET_bitIndexLazyFlush does not
        /// affect the laziness of data updates. If the indexing operations is interrupted by process
        /// termination, Soft Recovery will still be able to able to get the database to a consistent
        /// state, but the index may not be present.
        /// </summary>
        IndexLazyFlush = 0x80,

        /// <summary>
        /// Do not attempt to build the index, because all entries would evaluate to NULL. grbit MUST
        /// also specify JET_bitIgnoreAnyNull when JET_bitIndexEmpty is passed. This is a performance
        /// enhancement. For example if a new column is added to a table, then an index is created over
        /// this newly added column, all of the records in the table would be scanned even though they
        /// would never get added to the index anyway. Specifying JET_bitIndexEmpty skips the scanning
        /// of the table, which could potentially take a long time.
        /// </summary>
        IndexEmpty = 0x100,

        /// <summary>
        /// Causes index creation to be visible to other transactions. Normally a session in a
        /// transaction will not be able to see an index creation operation in another session. This
        /// flag can be useful if another transaction is likely to create the same index, so that the
        /// second index-create will simply fail instead of potentially causing many unnecessary database
        /// operations. The second transaction may not be able to use the index immediately. The index
        /// creation operation needs to complete before it is usable. The session must not currently be in
        /// a transaction to create an index without version information.
        /// </summary>
        IndexUnversioned = 0x200,

        /// <summary>
        /// Specifying this flag causes NULL values to be sorted after data for all columns in the index.
        /// </summary>
        IndexSortNullsHigh = 0x400,
    }

    /// <summary>
    /// Key definition grbits. Used when retrieving information about an index.
    /// </summary>
    public enum IndexKeyGrbit
    {
        /// <summary>
        /// Key segment is ascending.
        /// </summary>
        Ascending = 0x0,

        /// <summary>
        /// Key segment is descending.
        /// </summary>
        Descending = 0x1,
    }

    /// <summary>
    /// Options for the JET_CONDITIONALCOLUMN structure.
    /// </summary>
    public enum ConditionalColumnGrbit
    {
        /// <summary>
        /// The column must be null for an index entry to appear in the index.
        /// </summary>
        ColumnMustBeNull = 0x1,

        /// <summary>
        /// The column must be non-null for an index entry to appear in the index.
        /// </summary>
        ColumnMustBeNonNull = 0x2,
    }

    /// <summary>
    /// Options for temporary table creation.
    /// </summary>
    /// <seealso cref="Server2003Grbits.ForwardOnly"/>
    /// <seealso cref="Windows7Grbits.IntrinsicLVsOnly"/>
    [Flags]
    public enum TempTableGrbit
    {
        /// <summary>
        /// Default options.
        /// </summary>
        None = 0,

        /// <summary>
        /// This option requests that the temporary table be flexible enough to 
        /// permit the use of JetSeek to lookup records by index key. If this 
        /// functionality it not required then it is best to not request it. If this 
        /// functionality is not requested then the temporary table manager may be 
        /// able to choose a strategy for managing the temporary table that will 
        /// result in improved performance. 
        /// </summary>
        Indexed = 0x1,

        /// <summary>
        /// This option requests that records with duplicate index keys be removed 
        /// from the final set of records in the temporary table. 
        /// Prior to Windows Server 2003, the database engine always assumed this 
        /// option to be in effect due to the fact that all clustered indexes must 
        /// also be a primary key and thus must be unique. As of Windows Server 
        /// 2003, it is now possible to create a temporary table that does NOT 
        /// remove duplicates when the <see cref="Server2003Grbits.ForwardOnly"/>
        /// option is also specified. 
        /// It is not possible to know which duplicate will win and which duplicates 
        /// will be discarded in general. However, when the 
        /// <see cref="ErrorOnDuplicateInsertion"/> option is requested then the first 
        /// record with a given index key to be inserted into the temporary table 
        /// will always win. 
        /// </summary>
        Unique = 0x2,

        /// <summary>
        /// This option requests that the temporary table be flexible enough to 
        /// allow records that have previously been inserted to be subsequently 
        /// changed. If this functionality it not required then it is best to not 
        /// request it. If this functionality is not requested then the temporary 
        /// table manager may be able to choose a strategy for managing the 
        /// temporary table that will result in improved performance. 
        /// </summary>
        Updatable = 0x4,

        /// <summary>
        /// This option requests that the temporary table be flexible enough to 
        /// allow records to be scanned in arbitrary order and direction using 
        /// <see cref="Api.JetMove(Microsoft.Isam.Esent.Interop.JET_SESID,Microsoft.Isam.Esent.Interop.JET_TABLEID,int,Microsoft.Isam.Esent.Interop.MoveGrbit)"/>.
        /// If this functionality it not required then it is best to not 
        /// request it. If this functionality is not requested then the temporary 
        /// table manager may be able to choose a strategy for managing the 
        /// temporary table that will result in improved performance. 
         /// </summary>
        Scrollable = 0x8,

        /// <summary>
        /// This option requests that NULL key column values sort closer
        /// to the end of the index than non-NULL key column values.
        /// </summary>
        SortNullsHigh = 0x10,

        /// <summary>
        /// This option forces the temporary table manager to abandon
        /// any attempt to choose a clever strategy for managing the
        /// temporary table that will result in enhanced performance.
        /// </summary>
        ForceMaterialization = 0x20,

        /// <summary>
        /// This option requests that any attempt to insert a record with the same 
        /// index key as a previously inserted record will immediately fail with 
        /// <see cref="JET_err.KeyDuplicate"/>. If this option is not requested then a duplicate 
        /// may be detected immediately and fail or may be silently removed later 
        /// depending on the strategy chosen by the database engine to implement the 
        /// temporary table based on the requested functionality. If this 
        /// functionality it not required then it is best to not request it. If this 
        /// functionality is not requested then the temporary table manager may be 
        /// able to choose a strategy for managing the temporary table that will 
        /// result in improved performance. 
        /// </summary>
        ErrorOnDuplicateInsertion = 0x20,
    }

    /// <summary>
    /// Options for <see cref="Api.JetIdle"/>.
    /// </summary>
    [Flags]
    public enum IdleGrbit
    {
        /// <summary>
        /// Default options.
        /// </summary>
        None = 0x0,

        /// <summary>Triggers cleanup of the version store.</summary>
        FlushBuffers = 0x01,

        /// <summary>
        /// Reserved for future use. If this flag is specified, the API will return <see cref="JET_err.InvalidGrbit"/>.
        /// </summary>
        Compact = 0x02,

        /// <summary>
        /// Returns <see cref="JET_wrn.IdleFull"/> if version store is more than half full.
        /// </summary>
        GetStatus = 0x04,
    }
}